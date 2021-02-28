CREATE TABLE  Products  (
    Id    bigint             NOT NULL identity(1,1) PRIMARY KEY ,    
    Name             NVARCHAR (50)    NOT NULL,  
    ShortDescription NVARCHAR (120)   NULL,
    LongDescription  NVARCHAR (MAX)   NULL,
    Price            MONEY            NOT NULL
   
);




CREATE TABLE Customers (
    Id   bigint     NOT NULL identity(1,1) PRIMARY KEY ,  
    FirstName  NVARCHAR (50)    NOT NULL,
    LastName    NVARCHAR (50)    NOT NULL,
    Email       NVARCHAR (100)   NOT NULL
   
);


CREATE TABLE Orders( 
    Id          bigint     NOT NULL identity(1,1) PRIMARY KEY ,
    CustomerId  bigint     NOT NULL references Customers(Id) ,
    ProductId   bigint     NOT NULL references Products(Id) ,
    Quantity    int        not null,
    OrderDate   datetime   not null
)
