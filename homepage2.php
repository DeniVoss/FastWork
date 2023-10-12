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

$mysqli->close();
?>

<!DOCTYPE html>
<html>
<head>
  <title>FastWork</title>
  <link rel="stylesheet" type="text/css" href="homepage.css">
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

  <div id="container">
  <p id="text-fastwork">Com a FastWork</p>
  <p id="text-procura">Nunca foi tão fácil encontrar<br>o trabalho que procura<br>pelo tempo que procura !</p>
</div>
</body>
</html>
