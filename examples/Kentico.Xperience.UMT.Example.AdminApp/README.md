# Admin sample

## Development setup

1. Use this sample in your Xperience project (AddUmtSample, UseUmtSample)

2. Configure the UI of this module to be served from dev server
	```json
    "CMSAdminClientModuleSettings": {
     "umt-web-admin": {
        "Mode": "Proxy",
        "Port": 3009
      }
    }
    ```
 
3. Serve static files:
	- Copy content of Client/assets folder into static files folder of your Xperience project. 
    - The static files folder is assumed to be available at /assets URL path
    
4. Run development server
	- Go to Client folder
	- `npm run start`


## Backend service mockup
- The backend service can be replaced by a mockup for the purpose of frontend development
- In CustomLayoutTemplate.tsx, import from mock-import-service instead of backend-import-service
- When using mockup, you can use arbitrary file for testing. The file is not parsed for data

## Usage
1. Open XbK administration interface
2. Click on Universal Migration Toolkit tile
3. Follow the UI instructions