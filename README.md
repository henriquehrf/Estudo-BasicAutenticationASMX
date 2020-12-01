# Estudo-BasicAutenticationASMX
Exemplo de autenticação básica utilizando web service ASMX.

<h1>Sobre o projeto</h1>
Este projeto demonstra uma maneira simples e rápida de autenticação em web service asmx. A estrutura do projeto é bem simplista com o foco em uma implementação rápida, sendo assim, as informações de token e entre outras estão armazenadas em memória.

Além disto, vale salientar que este projeto buscou implementar os conceitos de IoC (Inversion of Control) em uma estrutura árdua que é os ASMX. Vale os créditos ao site <a href="https://ruijarimba.wordpress.com/2011/12/27/asp-net-web-services-dependency-injection-using-unity/"  target="_blank">Rui Jarimba</a> que tomei como base para a implementação do IoC.

<h1>Tecnologias</h1>
<ul>
<li>.Net Framework 4.8</li>
<li>Unity.Abstraction 3.3.0</li>
<li>Unity.Container 5.8.6</li>
<li>Microsoft.AspNet.WebFormsDependencyInjetion.Unity 1.0.0</li>
</ul>

<h1>Como testar o projeto</h1>

<ol>
<li>Baixe o projeto</li>
<li>Execute o projeto no VS</li>
<li>WebService Autenticação: http://.../BasicAutenticationASMX/WebService/WSAuth.asmx</li>
<li>WebService DoSomething: http://.../BasicAutenticationASMX/WebService/DoSomething.asmx</li>
</ol>

Para adicionar e/ou alterar novos usuário, vide a classe <strong>AuthDAO.cs</strong>.

Enjoy ;)
