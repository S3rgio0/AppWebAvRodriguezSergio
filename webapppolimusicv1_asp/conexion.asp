<%
' Conexión SQL Server para la base de datos BDD.
Const adUseClient = 3

Dim conn
Set conn = Server.CreateObject("ADODB.Connection")
conn.ConnectionString = "Provider=MSOLEDBSQL;" & _
                        "Data Source=localhost,1433;" & _
                        "Initial Catalog=BDD;" & _
                        "User ID=sa;" & _
                        "Password=TuClaveSegura123!;" & _
                        "Encrypt=Optional;TrustServerCertificate=True;"
conn.Open
%>
