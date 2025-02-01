CREATE TABLE tabela_telefone (
    id INT PRIMARY KEY AUTO_INCREMENT,
    telefone VARCHAR(200) NOT NULL,
    pessoa_id INT,
    CONSTRAINT fk_pessoa FOREIGN KEY (pessoa_id) REFERENCES tabela_pessoa(id) ON DELETE CASCADE
);
