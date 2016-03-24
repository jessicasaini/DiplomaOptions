Enable-Migrations -ContextProject DiplomaDataModel -ContextTypeName BCITContext -MigrationsDirectory Migrations\BCITMigrations

add-migration -ConfigurationTypeName OptionsWebsite.Migrations.BCITMigrations.Configuration "SecondCreate"

update-database -ConfigurationTypeName OptionsWebsite.Migrations.BCITMigrations.Configuration



Enable-Migrations -ContextProject DiplomaDataModel -ContextTypeName ApplicationDbContext -MigrationsDirectory Migrations\IdentityMigrations

add-migration -ConfigurationTypeName OptionsWebsite.Migrations.IdentityMigrations.Configuration "InitialCreate"


update-database -ConfigurationTypeName OptionsWebsite.Migrations.IdentityMigrations.Configuration