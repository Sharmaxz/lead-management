# Lead Management System

Este repositório contém um sistema de gerenciamento de leads, dividido em dois projetos:

1. **Frontend:** Aplicação React utilizando Ant Design e Axios para consumir a API.
2. **Backend:** API RESTful desenvolvida em .NET para gerenciamento dos leads.

## 🛠️ **Pré-requisitos**
Certifique-se de ter as seguintes ferramentas instaladas em sua máquina:

- [Node.js](https://nodejs.org/) (Recomendado: LTS)
- [Yarn](https://yarnpkg.com/) ou [NPM](https://www.npmjs.com/)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- Banco de Dados **SQL Server** ou **SQLite** (pode ser configurado no `appsettings.json` do backend)

## 🚀 **Rodando o Projeto**
### **📌 Clonar o repositório**
```bash
git clone https://github.com/Sharmaxz/lead-management.git
cd lead-management
```

---

### **📦 Rodando o Backend (.NET API)**
1. Acesse a pasta do backend:
   ```bash
   cd LeadManagement
   ```

2. Instale as dependências:
   ```bash
   dotnet restore
   ```

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`.

4. **Execute as migrações do banco de dados**:
   ```bash
   dotnet ef database update
   ```

5. **Inicie a API**:
   ```bash
   dotnet run
   ```
   A API estará disponível em `https://localhost:7168`.

   O Swagger estará disponível em `https://localhost:7168/swagger/index.html`.
---

### **🖥️ Rodando o Frontend (React)**
1. Acesse a pasta do frontend:
   ```bash
   cd lead-management-frontend
   ```

2. Instale as dependências:
   ```bash
   npm install
   ```

3. **Verifique a URL da API** no arquivo `src/pages/lead/Leads.tsx`:
   ```js
    axios.get("https://localhost:7168/api/leads")
        .then(response => setLeads(response.data))
        .catch(error => console.error("Erro ao buscar leads:", error));
   ```

4. **Inicie o servidor de desenvolvimento**:
   ```bash
   npm start
   ```


5. O frontend estará disponível em `http://localhost:5173`.

---

## 🌟 **Tecnologias Utilizadas**
- **Backend**: .NET 6, Entity Framework, MediaR
- **Frontend**: React, Ant Design, Axios  
- **Banco de Dados**: SQL Server e SQLite

---

## 🗃️ **Licença**
Este projeto está sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
