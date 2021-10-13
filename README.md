# APIRest

Construa uma API Rest. Nesta API utilize tokens para tratar da
segurança da aplicação, podendo ser um token estático (definir uma chave de
acesso única) e não dinâmico. Você deve criar a estrutura do banco de dados.

A cada nova encomenda é criado um pedido no banco de dados, cada
pedido tem o seu número de identificação, data de criação, data da entrega
realizada e endereço. Cada pedido pode conter vários produtos, e de cada um é
guardado o nome, descrição e valor. Cada encomenda é destinada a uma equipe e
desta se sabe o nome, descrição e placa do veículo utilizado.

O único endpoint irá retornar todos os pedidos ordenados por data de criação
e paginado (dados de paginação devem vir como parâmetro passado pelo
front-end)
