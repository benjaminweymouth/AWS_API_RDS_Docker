 ![1](https://user-images.githubusercontent.com/47256041/168893936-0486efd2-d285-4ad9-9253-760aa4517be1.png)


# FinTech Analytics Inc: An API Project
# Featuring: API client, Docker, AWS, RDS and C#, ASP.net
This project is to demonstrate an understanding of API's in relation to AWS services and ASP.net core MVC. The project utilizes AWS, API, RDS, Docker, MVC pattern, ASP.net core MVC. Front End, BackEnd and API Integration. (Benjamin Weymouth and Michael Asemota) 

# Core Motivations of this Project & Research Goals: 

Our motivation is to help both individuals and corporations in Canada to rebuild their revenue streams after COVID by making good financial decisions,
How do we do this? Simply put, our API helps Canadians by publishing both volatility data and survey data. A combined powerhouse: with both survey data and quantitative analysis, we will provide an open methodology for Canadians to improve their financial choices. 

# Databases / Backend Structures: 

Our Backend draws data sources both from individuals and from corporate data sets. This section has our ER diagram, arch diagram and DB structure. 

1) We used AWS RDS and MSSQL Server management studio to import a CSV of real Corporate Data to create an API that shows stock information that includes S&P500 companies and their volatility. 
2) We used user-generated survey data to populate another AWS RDS / MSSQL Server table to generate survey data on stock preferences. 

Together, these two pipelines provide the core of our data set. 
 
# Architecture Diagram 

![Architecture Diagram](https://user-images.githubusercontent.com/47256041/168900782-545289fb-8a8c-4648-a231-30a94a6ea24d.png)

# Front End Client

Our Front End allows for 5 CRUD operations: get, getbyid, put, post and delete. Each controller implements these 5 operations. 
Our solution file has 3 sections: the Front End, the Class Library and the API Client, and both our Front End and our API Client were deployed on AWS Elastic Beanstalk.  

![image](https://user-images.githubusercontent.com/47256041/168895843-e2db81b6-8b61-403e-b444-a752de5cc643.png)
 
# Futher Information: Slidedeck

For further information on this project please peruse our slide deck. 

Download the slide deck here: https://github.com/benjaminweymouth/AWS_API_RDS_Docker/raw/main/FinTech%20Analytics%20SlideDeck.pptx



