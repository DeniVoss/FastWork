-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 07-Jul-2023 às 00:18
-- Versão do servidor: 10.4.28-MariaDB
-- versão do PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `pap`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `post`
--

CREATE TABLE `post` (
  `id` int(11) NOT NULL,
  `utilizador_id` int(11) DEFAULT NULL,
  `titulo` varchar(255) DEFAULT NULL,
  `empresa` varchar(255) DEFAULT NULL,
  `tipoTrabalho` varchar(255) DEFAULT NULL,
  `ordenado` varchar(20) DEFAULT NULL,
  `tempo` varchar(255) DEFAULT NULL,
  `descricao` text DEFAULT NULL,
  `data_criacao` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `post`
--

INSERT INTO `post` (`id`, `utilizador_id`, `titulo`, `empresa`, `tipoTrabalho`, `ordenado`, `tempo`, `descricao`, `data_criacao`) VALUES
(1, 1, 'Assistente de Recursos Humanos Temporário para Empresa de Tecnologia', 'TechInovação', 'Temporario', '600€- 800€', '11 - 20 dias', 'A TechInovação, uma empresa de tecnologia em rápido crescimento, está buscando um Assistente de Recursos Humanos Temporário para auxiliar nas atividades do departamento durante um projeto especial. O(a) candidato(a) ideal será responsável por auxiliar na triagem de currículos, agendar entrevistas, acompanhar processos de integração e apoio administrativo geral. Esta é uma oportunidade emocionante para ganhar experiência em uma empresa inovadora e colaborativa no setor de tecnologia.', '2023-07-06 22:28:52'),
(2, 1, 'Operador de Produção para Indústria Alimentícia', 'SaborDelícia', 'Voluntario', '800€- 1000€', '6 - 12 meses', 'A SaborDelícia, uma renomada empresa do ramo alimentício, está contratando Operadores de Produção para auxiliar na linha de produção durante a alta demanda da temporada. O(a) candidato(a) selecionado(a) será responsável por realizar tarefas como preparação de ingredientes, operação de máquinas, embalagem de produtos e controle de qualidade. Se você é detalhista, possui habilidades manuais e está interessado(a) no setor de alimentos, essa é uma ótima oportunidade para ganhar experiência em uma empresa estabelecida.', '2023-07-06 22:34:23'),
(3, 1, 'Motorista  para Empresa de Transportes', 'TransExpresso', 'Full-Time', '800€- 1000€', '6 - 12 meses', 'A TransExpresso, uma empresa líder no setor de transportes, está procurando Motoristas para ajudar na entrega de mercadorias durante o período de pico de demanda. O(a) candidato(a) selecionado(a) será responsável por conduzir veículos de carga, seguir rotas pré-estabelecidas, realizar a conferência de mercadorias e garantir a entrega pontual aos clientes. Se você possui carta de condução válida, experiência em condução segura e habilidades de organização, essa é uma oportunidade para se juntar a uma equipe dinâmica e contribuir para a logística eficiente da empresa.', '2023-07-06 22:36:10'),
(4, 1, 'Técnico de Suporte Temporário para Empresa de IT', 'Técnico de Suportepara Empresa de TI', 'Full-Time', '1000€- 1500€', 'Negociavel', ' A TechSupport, uma empresa de serviços de tecnologia, está buscando um Técnico de Suporte para auxiliar no atendimento a clientes durante um projeto de atualização de sistemas. O(a) candidato(a) selecionado(a) será responsável por fornecer suporte técnico via telefone, chat e e-mail, solucionar problemas de hardware e software, e auxiliar na configuração e instalação de equipamentos. Se você possui conhecimentos técnicos em TI, habilidades de resolução de problemas e capacidade de comunicação clara, essa é uma oportunidade para fazer parte de uma equipe dedicada a fornecer excelência em serviços de suporte.', '2023-07-06 22:37:03'),
(5, 1, 'Trabalho facil rapido casino', 'SolVerde', 'Part-Time', 'Sem Remuneração', '1 - 10 dias', 'Vender fichas de poker no casino', '2023-07-06 23:18:05');

-- --------------------------------------------------------

--
-- Estrutura da tabela `suporte`
--

CREATE TABLE `suporte` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `titulo` varchar(255) NOT NULL,
  `descricao` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `suporte`
--

INSERT INTO `suporte` (`id`, `email`, `titulo`, `descricao`) VALUES
(1, '*********@gmail.com', 'Duvida sobre \"\"', 'Preciso de ajuda com \"\" e com \"\"'),
(2, '*********@gmail.com', 'ajuda', 'ajuda');

-- --------------------------------------------------------

--
-- Estrutura da tabela `suporteutilizador`
--

CREATE TABLE `suporteutilizador` (
  `idUtilizadorSuporte` int(11) NOT NULL,
  `Utilizador` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `suporteutilizador`
--

INSERT INTO `suporteutilizador` (`idUtilizadorSuporte`, `Utilizador`, `Password`) VALUES
(1, 'admin', 'admin');

-- --------------------------------------------------------

--
-- Estrutura da tabela `utilizador`
--

CREATE TABLE `utilizador` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `apelido` varchar(50) DEFAULT NULL,
  `utilizador` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `numero` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `utilizador`
--

INSERT INTO `utilizador` (`id`, `nome`, `apelido`, `utilizador`, `email`, `password`, `numero`) VALUES
(1, 'fast', 'work', 'FastWork', '************@gmail.com', '1234', 111111111),
(2, 'Pedro', 'Oliveira', 'AntonioSilva', '**********@gmail.com', '1234', 111111111);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `post`
--
ALTER TABLE `post`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `suporte`
--
ALTER TABLE `suporte`
  ADD PRIMARY KEY (`id`);

--
-- Índices para tabela `suporteutilizador`
--
ALTER TABLE `suporteutilizador`
  ADD PRIMARY KEY (`idUtilizadorSuporte`);

--
-- Índices para tabela `utilizador`
--
ALTER TABLE `utilizador`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `post`
--
ALTER TABLE `post`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `suporte`
--
ALTER TABLE `suporte`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `suporteutilizador`
--
ALTER TABLE `suporteutilizador`
  MODIFY `idUtilizadorSuporte` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `utilizador`
--
ALTER TABLE `utilizador`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
