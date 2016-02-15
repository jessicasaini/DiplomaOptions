Enable-Migrations -ContextTypeName BCITContext -MigrationsDirectory Migrations\BCITMigrations

add-migration -ConfigurationTypeName OptionsWebsite.Migrations.BCITMigrations.Configuration "InitialCreate"

update-database -ConfigurationTypeName OptionsWebsite.Migrations.BCITMigrations.Configuration