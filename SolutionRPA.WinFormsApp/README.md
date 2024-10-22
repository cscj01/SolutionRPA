# SolutionRPA

SolutionRPA é um RPA Web Scraping(raspagem de dados) do portal da Alura Cursos Online(https://www.alura.com.br/).

## Installation DB

Usa o package manager para criar e migrar o banco de dados pelo EF(EntityFramework)

Duplique a connectionStrings nos projetos:
 -> SolutionRPA.WinFormsApp
 -> SolutionRPA.Infra.Data

## Usage

Selecionar o projeto -> SolutionRPA.Infra.Data

```c#
Enable-Migrations

mudar a propriedade "AutomaticMigrationsEnabled" para "true", no arquivo Migrations ->  Configuration ;

Update-Database -verbose
```

## Contributing

 - Claudio Coelho


## License

[MIT](https://choosealicense.com/licenses/mit/)