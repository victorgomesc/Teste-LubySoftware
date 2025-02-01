DELETE FROM tabela_pessoa
WHERE id NOT IN (
    SELECT p.id
    FROM tabela_pessoa p
    LEFT JOIN tabela_evento e ON p.id = e.pessoa_id
    WHERE e.pessoa_id IS NOT NULL
);
