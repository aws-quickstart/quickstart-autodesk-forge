using Autodesk.Forge;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.Runtime;

namespace forgeSample.Controllers
{
    [ApiController]
    public class OAuthController : ControllerBase
    {
        // As both internal & public tokens are used for all visitors
        // we don't need to request a new token on every request, so let's
        // cache them using static variables. Note we still need to refresh
        // them after the expires_in time (in seconds)
        private static dynamic InternalToken { get; set; }
        private static dynamic PublicToken { get; set; }

        /// <summary>
        /// Get access token with public (viewables:read) scope
        /// </summary>
        [HttpGet]
        [Route("api/forge/oauth/token")]
        public async Task<dynamic> GetPublicAsync()
        {
            if (PublicToken == null || PublicToken.ExpiresAt < DateTime.UtcNow)
            {
                PublicToken = await Get2LeggedTokenAsync(new Scope[] { Scope.ViewablesRead });
                PublicToken.ExpiresAt = DateTime.UtcNow.AddSeconds(PublicToken.expires_in);
            }
            return PublicToken;
        }

        /// <summary>
        /// Get access token with internal (write) scope
        /// </summary>
        public static async Task<dynamic> GetInternalAsync()
        {
            if (InternalToken == null || InternalToken.ExpiresAt < DateTime.UtcNow)
            {
                InternalToken = await Get2LeggedTokenAsync(new Scope[] { Scope.BucketCreate, Scope.BucketRead, Scope.BucketDelete, Scope.DataRead, Scope.DataWrite, Scope.DataCreate, Scope.CodeAll });
                InternalToken.ExpiresAt = DateTime.UtcNow.AddSeconds(InternalToken.expires_in);
            }

            return InternalToken;
        }

        /// <summary>
        /// Get the access token from Autodesk
        /// </summary>
        private static async Task<dynamic> Get2LeggedTokenAsync(Scope[] scopes)
        {
            TwoLeggedApi oauth = new TwoLeggedApi();
            string grantType = "client_credentials";
            dynamic bearer = await oauth.AuthenticateAsync(
                await GetAppSetting("FORGE_CLIENT_ID"),
                await GetAppSetting("FORGE_CLIENT_SECRET"),
                grantType,
                scopes);
            return bearer;
        }

        public static async Task<string> GetForgeKeysSSM(string SSMkey)
        {
            try
            {
                AWSCredentials awsCredentials = new InstanceProfileAWSCredentials();
                GetParameterRequest parameterRequest = new GetParameterRequest() { Name = SSMkey };
                AmazonSimpleSystemsManagementClient client = new AmazonSimpleSystemsManagementClient(awsCredentials, Amazon.RegionEndpoint.GetBySystemName( Environment.GetEnvironmentVariable("AWS_REGION")));
                GetParameterResponse response = await client.GetParameterAsync(parameterRequest);
                return response.Parameter.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Cannot obtain Amazon SSM value for " + SSMkey, e);
            }
        }

        /// <summary>
        /// Reads appsettings from web.config or AWS SSM Parameter Store
        /// </summary>
        public static async Task<string> GetAppSetting(string settingKey)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == "Development"){       
                return Environment.GetEnvironmentVariable(settingKey);
            }
            else if (environment == "Production") {
                string SSMkey = Environment.GetEnvironmentVariable(settingKey);
                return await GetForgeKeysSSM(SSMkey);
            }
            return string.Empty;
        }
    }
}