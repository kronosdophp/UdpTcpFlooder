# UdpTcpFlooder

## Descrição

UdpTcpFlooder é uma ferramenta de ataque UDP/TCP desenvolvida em C#. Ela permite que os usuários executem ataques de flood UDP e TCP contra um IP e porta especificados. 

## Como Funciona

A ferramenta solicita ao usuário o IP de destino, a porta, o tipo de ataque (UDP ou TCP) e a duração do ataque. Em seguida, inicia várias threads para enviar pacotes UDP ou TCP para o destino especificado. O ataque pode ser interrompido manualmente pressionando a tecla ENTER.

## Requisitos

- .NET Framework

## Uso

1. Clone o repositório para sua máquina local.
2. Abra o projeto em um IDE compatível com C# (Visual Studio, por exemplo).
3. Compile e execute o projeto.

### Passos

1. Ao iniciar, o programa exibirá um ASCII Art e algumas mensagens animadas.
2. O usuário será solicitado a fornecer as seguintes informações:
    - IP de destino
    - Porta de destino
    - Tipo de ataque (UDP/TCP)
    - Duração do ataque (em segundos)
3. O ataque será iniciado e os pacotes serão enviados para o destino especificado.
4. Pressione ENTER a qualquer momento para parar o ataque manualmente.

## Exemplo de Uso

```plaintext
===== UDP/TCP Attack =====
Ferramenta de ataque UDP/TCP
Digite o IP: 192.168.1.1
Digite a porta: 8080
Tipo de ataque (UDP/TCP): UDP
Duração do ataque (em segundos): 60

Iniciando ataque...
IP: 192.168.1.1, Porta: 8080, Tipo: UDP, Duração: 60s

Pressione ENTER para parar o ataque manualmente.
```

## Configurações de Proxy

Se necessário, você pode configurar um proxy para os ataques TCP. Defina o endereço do proxy, a porta, o usuário e a senha nas variáveis `proxyAddress`, `proxyPort`, `proxyUser` e `proxyPass`.

## Aviso Legal

Esta ferramenta é fornecida apenas para fins educacionais. O uso inadequado desta ferramenta pode ser ilegal. O autor não se responsabiliza por qualquer dano causado pelo uso desta ferramenta. Use por sua própria conta e risco.

## Contribuindo

Se você encontrar algum problema ou tiver sugestões para melhorias, sinta-se à vontade para abrir uma issue ou enviar um pull request.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
