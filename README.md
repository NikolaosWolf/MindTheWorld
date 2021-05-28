# MindTheWorld

## Overview
**MindTheWorld application is composed by 3 solutions**
1. The Database solution, that contains the tables,
2. The Server solution, which is a Web API,
3. The Client solution

### The Server
#### Overview
The server was developed using a 3-layer architecure, which is composed of:
1. The REST layer, which contains the Controllers and our DTOs,
2. The Service layer (Business layer), which contains all services,
3. The Repository layer (Data-Access layer), which contains the repositories and the domain represantation.

#### Importing .csv files
1. Sending a POST request of a format like "baseUrli/api/import/{indexName}" with the .csv file on the body, the ImportController accepts it and feeds it to the proper service.
2. The corresponding service, using the GenericParser package, transforms the .csv file to a DataTable. After this process, it is further transformed to the corresponing Entity Model collection. Then it feeds the collection to the repository.
3. The repository saves the Entities to the Database.
![csv-import-flow](https://user-images.githubusercontent.com/51601380/119984985-bff90880-bfca-11eb-911f-82f5524fa546.png)


### The Client
#### Overview
The client was developed using Blazor Wasm and ChartJs.Blazor for the visual represantation of our data through some charts.
