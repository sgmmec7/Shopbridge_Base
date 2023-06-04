1. This Project is using Services Oriented Architecture.
2. I am using Entity Framework Database First Approach for database operations.
3. I am attaching sql script file "Thinkbridge.sql" only containing schema.
4. Connectionstring username and password can be changed accordingly to run the project.
5. This project can be used with repository pattern also, we have to keep 3 layers 
	i.e. DataLayer for database operations , controller layer for chaining of methods
	(it means according to previous value we have to call  further methods) 
	and repository layer act as intermediate layer between controller layer and data layer.