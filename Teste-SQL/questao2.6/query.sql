DELETE FROM tabela_pessoa
WHERE id NOT IN (SELECT DISTINCT pessoa_id FROM tabela_evento WHERE pessoa_id IS NOT NULL);
