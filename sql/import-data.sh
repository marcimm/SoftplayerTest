# Aguardar 30 segundos para o provisionamento e start do banco
sleep 30s
# Criação do banco de dados via comando
/opt/mssql-tools/bin/sqlcmd -S localhost,1433 -U SA -P "My_PassW0rd" -i database-generator.sql