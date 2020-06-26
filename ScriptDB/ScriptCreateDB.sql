-- Criação do banco de dados
create database SportsXDb
go
use SportsXDb
go
-- Procedure para criação de trigger default para preenchimento do campo DtUpdated
create procedure sp_defaultTriggerUpdated @tableTrigger varchar(100)
as
begin
	declare @sql nvarchar(max)

	set @sql = 'create trigger tr_'+@tableTrigger+' on '+@tableTrigger+' after update
				as
				begin
					update tb set DtUpdated = getdate()
					from '+@tableTrigger+' tb
					where exists(
						select 1
						from deleted d
						where d.Id = tb.id
					)
				end'
	exec sp_executesql @sql
end
go
-- Tabela de tipos de cliente
create table clientType(
	Id int not null Primary Key identity,
	Name varchar(100) not null,
	DtCriation datetime not null default(getdate()),
	DtUpdated datetime null
)
go
-- Execução da procedure de criação de trigger para atualização automatica do campo DtUpdated
exec sp_defaultTriggerUpdated 'clientType'
go
-- Dados iniciais do tipo de cliente
insert into clientType(Name)
values('Pessoa Física'),
('Pessoa Jurídica')
go
-- Tabela de classificação do cliente
create table classification(
	Id int not null Primary Key identity,
	Name varchar(100) not null,
	DtCriation datetime not null default(getdate()),
	DtUpdated datetime null
)
go
-- Execução da procedure de criação de trigger para atualização automatica do campo DtUpdated
exec sp_defaultTriggerUpdated 'classification'
go
-- Dados iniciais da classificação do cliente
insert into classification(Name)
values('Ativo'),
('Inativo'),
('Preferencial')
go
-- Tabela de clientes
create table client(
	Id int not null Primary Key identity,
	Name varchar(100) not null,
	CompanyName varchar(100) null,
	CpfCnpj varchar(18) null,
	Email varchar(500) not null,
	Cep varchar(10) null,
	IdClassification int not null,
	IdClientType int not null,
	DtCriation datetime not null default(getdate()),
	DtUpdated datetime null,
	constraint Fk_Client_Classification foreign key (IdClassification) references classification(Id),
	constraint Fk_Client_ClientType foreign key (IdClientType) references clientType(Id)
)
go
-- Execução da procedure de criação de trigger para atualização automatica do campo DtUpdated
exec sp_defaultTriggerUpdated 'client'
go
-- Tabela de telefones dos clientes
create table telephone(
	Id int not null Primary Key identity,
	IdClient int not null,
	Number varchar(15) not null,
	DtCriation datetime not null default(getdate()),
	DtUpdated datetime null,
	constraint Fk_Telephone_Client foreign key (IdClient) references client(Id)
)
go
-- Execução da procedure de criação de trigger para atualização automatica do campo DtUpdated
exec sp_defaultTriggerUpdated 'telephone'
go