<Query Kind="Program">
  <Connection>
    <ID>d1e2bfba-7601-4790-810f-4978b4e9719d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>aspnet-SandboxContext-58504e08-4e0b-4565-af91-9fa864c5960a</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var result = from user in AspNetUsers
				from userRole in user.UserAspNetUserRoles
				where userRole.Role.Name == "Clients"
				select new 
				{
					ClientEmail = user.Email,
					ClientID = user.Id
					
				};
			result.Dump();	
}

// Define other methods and classes here
