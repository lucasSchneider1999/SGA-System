# Sistema de Gestão para Açougue (SGA)

## 📝 Visão Geral
Sistema desktop desenvolvido para operação local (PDV e Retaguarda), com foco em alta eficiência, baixo consumo de recursos e aplicação de práticas avançadas de engenharia de software.

## 🏗️ Arquitetura do Projeto
O projeto segue a **Clean Architecture** simplificada e o padrão **MVVM (Model-View-ViewModel)** para garantir o desacoplamento entre a interface do usuário e a lógica de negócio.

### Estrutura de Pastas

```text
src/
├── SGA.Domain/                # Camada de Domínio (Regras de Negócio Puras)
│   ├── Entities/              # Entidades do sistema (ex: Produto, Venda, Lote)
│   ├── Interfaces/            # Contratos de repositórios e serviços
│   └── Exceptions/            # Exceções específicas de domínio
│
├── SGA.Application/           # Camada de Aplicação (Casos de Uso)
│   ├── UseCases/              # Lógica de orquestração de fluxos
│   ├── ViewModels/            # Lógica de apresentação para a UI
│   └── DTOs/                  # Objetos de transferência de dados
│
├── SGA.Infrastructure/      # Camada de Infraestrutura (Implementações Técnicas)
│   ├── Persistence/            # Banco de Dados (SQLite / Dapper / EF Core)
│   │   ├── Context/           # Configurações de banco de dados
│   │   └── Repositories/      # Implementações concretas dos repositórios
│   └── Hardware/              # Integração com Periféricos
│       ├── Scales/             # Comunicação com Balanças (Serial/USB)
│       ├── Printers/          # Impressão Térmica (ESC/POS)
│       └── Scanners/           # Leitores de Código de Barras
│
└── SGA.UI/                    # Camada de Interface (WPF)
    ├── Views/                  # Telas XAML
    ├── ViewModels/            # ViewModels de binding da UI
    ├── Assets/                # Recursos visuais (imagens, ícones)
    └── Resources/             # Localização e Traduções (Espanhol Paraguai)
```

## 🛠️ Stack Tecnológica
- **Linguagem:** C# (.NET 8+)
- **UI:** WPF (Windows Presentation Foundation)
- **Banco de Dados:** SQLite
- **Arquitetura:** Clean Architecture & MVVM

## 📋 Diretrizes de Desenvolvimento
- **Idioma do Código:** Inglês.
- **Idioma dos Comentários:** Português do Brasil.
- **Idioma da Interface (UI):** Espanhol Paraguai.
- **Performance:** Foco em hardware limitado (4GB RAM) e uso rigoroso de `async/await` para evitar travamentos de UI.
