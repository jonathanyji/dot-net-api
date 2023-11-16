
CREATE DATABASE IF NOT EXISTS notesdb;

USE notesdb;

CREATE TABLE IF NOT EXISTS users (
    id varchar(36) PRIMARY KEY,
    firstName varchar(255) NOT NULL,
    lastName varchar(255),
    email VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO users (id, firstName, lastName, email)
VALUES
('660e8400-e29b-41d4-a716-446655440001', 'John', 'Smith', 'JohnSmith@example.com');

CREATE TABLE IF NOT EXISTS notes (
    id varchar(36),
    userId varchar(36),
    title varchar(255),
    description varchar(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (userId) REFERENCES users(id)
);

INSERT INTO notes (id, title, description)
VALUES
  ('550e8400-e29b-41d4-a716-446655440000', 'Travel Journal', 'This is a test Journal notes'),
  ('550e8400-e29b-41d4-a716-446655440001', 'Work Journal', 'This is a test work Journal notes'),
  ('550e8400-e29b-41d4-a716-446655440002', 'Cooking Journal', 'This is a test Cooking Journal notes');