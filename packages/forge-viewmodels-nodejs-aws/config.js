/////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved
// Written by Forge Partner Development
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
/////////////////////////////////////////////////////////////////////

const awsParamStore = require( 'aws-param-store' );

const awsFlag = process.env.FORGE_AWS_FLAG;
const paramStore = {"region": process.env.AWS_REGION}

const clientId = process.env.FORGE_CLIENT_ID;
const clientSecret = process.env.FORGE_CLIENT_SECRET;

// Autodesk Forge AWS configuration for SSM service
module.exports = {

    // Required scopes for your application on server-side
    scopeInternal: ['bucket:create', 'bucket:read', 'data:read', 'data:create', 'data:write'],
    // Required scope of the token sent to the client
    scopePublic: ['viewables:read'],
    
    getParamStore: function() {
        // If not running on AWS, paramStore requires access and secret AWS Keys
        if (awsFlag){
            return paramStore;
        }else{
            paramStore.credentials = 
            {
                "accessKeyId" : process.env.accessKeyId,
                "secretAccessKey" : process.env.secretAccessKey
            };
        }
        return paramStore;                        
    },
    
    forgeAWSClientId: async function() {
        let parameter = await awsParamStore.getParameter( clientId , this.getParamStore());
        return parameter.Value;
    },

    forgeAWSClientSecret: async function() {
        let parameter = await awsParamStore.getParameter( clientSecret ,this.getParamStore());
        return parameter.Value;
    }
};