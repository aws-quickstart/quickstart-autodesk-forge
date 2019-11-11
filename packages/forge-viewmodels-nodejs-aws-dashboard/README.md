# forge-viewmodels-nodejs-aws

[![Node.js](https://img.shields.io/badge/Node.js-8.12.0-blue.svg)](https://nodejs.org/)
[![npm](https://img.shields.io/badge/npm-6.4.1-blue.svg)](https://www.npmjs.com/)
![Platforms](https://img.shields.io/badge/platform-windows%20%7C%20osx%20%7C%20linux-lightgray.svg)
[![License](http://img.shields.io/:license-MIT-blue.svg)](http://opensource.org/licenses/MIT)

[![oAuth2](https://img.shields.io/badge/oAuth2-v1-green.svg)](http://developer.autodesk.com/)
[![Data-Management](https://img.shields.io/badge/Data%20Management-v1-green.svg)](http://developer.autodesk.com/)
[![Viewer](https://img.shields.io/badge/Viewer-v7-green.svg)](http://developer.autodesk.com/)

![Intermediate](https://img.shields.io/badge/Level-Intermediate-blue.svg)

# Description

AWS Cloudformation Project


# Setup

For using this sample, you need an Autodesk developer credentials. Visit the [Forge Developer Portal](https://developer.autodesk.com), sign up for an account, then [create an app](https://developer.autodesk.com/myapps/create). For this new app, use **http://localhost:3000/api/forge/callback/oauth** as Callback URL, although is not used on 2-legged flow. Finally take note of the **Client ID** and **Client Secret**.

### Run locally

Install [NodeJS](https://nodejs.org).

Clone this project or download it. It's recommended to install [GitHub desktop](https://desktop.github.com/). To clone it via command line, use the following (**Terminal** on MacOSX/Linux, **Git Shell** on Windows):

    git clone https://github.com/autodesk-forge/autodesk.forge.aws.cloudformation.nodejs

To run it, install the required packages, set the enviroment variables with your client ID & secret and finally start it. Via command line, navigate to the folder where this repository was cloned and use the following:

Mac OSX/Linux (Terminal)

    npm install
    export FORGE_CLIENT_ID=<<YOUR CLIENT ID FROM DEVELOPER PORTAL>>
    export FORGE_CLIENT_SECRET=<<YOUR CLIENT SECRET>>
    npm start

Windows (use **Node.js command line** from Start menu)

    npm install
    set FORGE_CLIENT_ID=<<YOUR CLIENT ID FROM DEVELOPER PORTAL>>
    set FORGE_CLIENT_SECRET=<<YOUR CLIENT SECRET>>
    npm start

Open the browser: [http://localhost:3000](http://localhost:3000).

## Packages used

The [Autodesk Forge](https://www.npmjs.com/package/forge-apis) packages is included by default. 

Some other non-Autodesk packaged are used: 

[express](https://www.npmjs.com/package/express) for the server

[multer](https://www.npmjs.com/package/multer) for upload 

[aws-sdk](https://www.npmjs.com/package/aws-sdk) for AWS services 

[aws-param-store](https://www.npmjs.com/package/aws-param-store) for access to AWS SSM Parameter Store.
# License

This sample is licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT).
Please see the [LICENSE](LICENSE) file for full details.

## Written by

[Forge Partner Development](http://forge.autodesk.com)