# forge-viewmodels-netcore-aws

![Platforms](https://img.shields.io/badge/platform-Windows|MacOS-lightgray.svg)
![.NET](https://img.shields.io/badge/.NET%20Core-2.1-blue.svg)
[![License](http://img.shields.io/:license-MIT-blue.svg)](http://opensource.org/licenses/MIT)

[![oAuth2](https://img.shields.io/badge/oAuth2-v1-green.svg)](http://developer.autodesk.com/)
[![Data-Management](https://img.shields.io/badge/Data%20Management-v1-green.svg)](http://developer.autodesk.com/)
[![Viewer](https://img.shields.io/badge/Viewer-v7-green.svg)](http://developer.autodesk.com/)

![Intermediate](https://img.shields.io/badge/Level-Intermediate-blue.svg)

# Description

AWS Cloudformation Project

# Setup

## Prerequisites

1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). 
2. **Visual Studio** Community edition or **Visual Code**
3. **.NET Framework** basic knowledge with C#
4. **JavaScript** basic knowledge with **jQuery**

For using this sample, you need an Autodesk developer credentials. Visit the [Forge Developer Portal](https://developer.autodesk.com), sign up for an account, then [create an app](https://developer.autodesk.com/myapps/create) that uses Data Management and Model Derivative APIs. For this new app, use `http://localhost:3000/api/forge/callback/oauth` as Callback URL, although is not used on 2-legged flow. Finally take note of the **Client ID** and **Client Secret**.

## Running locally

Clone this project or download it (this `netcore` branch only). It's recommended to install [GitHub desktop](https://desktop.github.com/). To clone it via command line, use the following (**Terminal** on MacOSX/Linux, **Git Shell** on Windows):

    git clone -b netcore https://github.com/Autodesk-Forge/learn.forge.viewmodels.git
    
For Visual Studio, go to project properties and specify the environment variables. For Visual Code, create a new Debug Configuration with the environment variables:

- `FORGE_CLIENT_ID`: your Forge Client ID
- `FORGE_CLIENT_SECRET`: your Forge Client Secret
- `FORGE_CALLBACK_URL`: not used on this sample

Compile the solution, Visual Studio should download the NUGET packages ([Autodesk Forge](https://www.nuget.org/packages/Autodesk.Forge/), [RestSharp](https://www.nuget.org/packages/RestSharp) and [Newtonsoft.Json](https://www.nuget.org/packages/newtonsoft.json/))

Start the **forgesample** project, the **index.html** is marked as start page. At the webpage, the **New Bucket** blue button allow create new buckets (as of now, minimum input validation is implemented). For any bucket, right-click to upload a file (objects). For demonstration, objects **are not** automatically translated, but right-click on a object and select **Translate**. 

# Further Reading

Documentation:

- [BIM 360 API](https://developer.autodesk.com/en/docs/bim360/v1/overview/) and [App Provisioning](https://forge.autodesk.com/blog/bim-360-docs-provisioning-forge-apps)
- [Data Management API](https://developer.autodesk.com/en/docs/data/v2/overview/)
- [Viewer](https://developer.autodesk.com/en/docs/viewer/v6) 


## License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by
[Forge Partner Development](http://forge.autodesk.com)
