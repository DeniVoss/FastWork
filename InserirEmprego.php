<?php
session_start();

if (!isset($_SESSION['utilizador'])) {
    header("Location: login.php");
    exit();
}

if (isset($_GET['logout'])) {
    session_destroy();
    header("Location: login.php");
    exit();
}

$utilizadorID = $_SESSION['utilizador'];

require_once 'db_conn.php';


$query = "SELECT nome FROM utilizador WHERE id = $utilizadorID";
$result = $mysqli->query($query);

if ($result->num_rows > 0) {
    $row = $result->fetch_assoc();
    $nomeUtilizador = $row['nome'];
} else {
    $nomeUtilizador = "Nome do Utilizador";
}
?>
<!DOCTYPE html>
<html>
<head>
    <title>Inserir Emprego</title>
    <link rel="stylesheet" type="text/css" href="InserirEmpregos.css">
</head>
<body>
<div id="header">
  <a href="perfil.php" id="username"><?php echo $nomeUtilizador; ?></a>
  <h1 id="header-title">FastWork</h1>
  <a href="homepage2.php?logout=true" id="logout-btn">Logout</a>
</div>

  <div id="navbar">
    <a href="homepage2.php">Home</a>
    <a href="empregos.php">Oferta Empregos</a>
    <a href="InserirEmprego.php">Inserir Emprego</a>
    <a href="Suporte.php">Suporte</a>
  </div>
  <div class="container">
    <form action="processar_inserir_emprego.php" method="POST">
        <div class="campo">
            <label>Título:</label>
            <input type="text" name="titulo" required>
        </div>
        <div class="campo">
            <label>Empresa:</label>
            <input type="text" name="empresa" required>
        </div>
        <div class="campo">
            <label>Tipo de Trabalho:</label>
            <select name="tipoTrabalho" required>
                <option value="Part-Time">Part-Time</option>
                <option value="Full-Time">Full-Time</option>
                <option value="Voluntario">Voluntário</option>
                <option value="Temporario">Temporario</option>
            </select>
        </div>
        <div class="campo">
            <label>Remuneração:</label>
            <select name="ordenado" required>
                <option value="Sem Remuneração">Sem Remuneração</option>
                <option value="50€ - 100€">50€ - 100€</option>
                <option value="100€ - 200€">100€ - 200€</option>
                <option value="200€ - 400€">200€ - 400€</option>
                <option value="400€- 600€">400€- 600€</option>
                <option value="600€- 800€">600€- 800€</option>
                <option value="800€- 1000€">800€- 1000€</option>
                <option value="1000€- 1500€">1000€- 1500€</option>
                <option value="Negociavel">Negociavel</option>
            </select>
        </div>
        <div class="campo">
            <label>Tempo:</label>
            <select name="tempo" required>
                <option value="1 - 10 dias">1 - 10 dias</option>
                <option value="11 - 20 dias">11 - 20 dias</option>
                <option value="1 - 5 meses">1 - 5 meses</option>
                <option value="6 - 12 meses">6 - 12 meses</option>
                <option value="Negociavel">Negociavel</option>
            </select>
        </div>
        <div class="campo">
            <label>Descrição:</label>
            <textarea name="descricao" required></textarea>
        </div>
        <div class="campo">
        <button type="submit" class="botaoS">Inserir</button>
        </div>
    </form>
</div>
</body>
</html>
