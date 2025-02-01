SELECT p.id, p.nome, e.evento
FROM tabela_pessoa p
LEFT JOIN tabela_evento e ON p.id = e.pessoa_id;