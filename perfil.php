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

$query = "SELECT nome, apelido, email, utilizador, numero FROM utilizador WHERE id = $utilizadorID";
$result = $mysqli->query($query);

if ($result->num_rows > 0) {
    $row = $result->fetch_assoc();
    $nome = $row['nome'];
    $apelido = $row['apelido'];
    $email = $row['email'];
    $nomeUtilizador = $row['utilizador'];
    $numero = $row['numero'];
} else {
    $nome = "Nome do Usuário";
    $apelido = "Apelido do Usuário";
    $email = "E-mail do Usuário";
    $nomeUtilizador = "Nome de Utilizador";
    $numero = "Número do Usuário";
}

$queryPosts = "SELECT id, titulo, empresa, tipoTrabalho, ordenado, tempo, descricao FROM post WHERE utilizador_id = $utilizadorID";
$resultPosts = $mysqli->query($queryPosts);

$mysqli->close();
?>

<!DOCTYPE html>
<html>
<head>
  <title>Perfil do Utilizador</title>
  <link rel="stylesheet" type="text/css" href="perfil.css">
</head>
<body>
<div id="header">
    <a href="perfil.php" id="username"><?php echo $nome; ?></a>
    <h1 id="header-title">FastWork</h1>
    <a href="homepage2.php?logout=true" id="logout-btn">Logout</a>
  </div>
  
  <div id="navbar">
    <a href="homepage2.php">Home</a>
    <a href="empregos.php">Oferta Empregos</a>
    <a href="InserirEmprego.php">Inserir Emprego</a>
    <a href="Suporte.php">Suporte</a>
  </div>
  
  <div class="content">
    <h2>Perfil do Utilizador</h2>
    <p><strong>Nome:</strong> <?php echo $nome; ?></p>
    <p><strong>Apelido:</strong> <?php echo $apelido; ?></p>
    <p><strong>E-mail:</strong> <?php echo $email; ?></p>
    <p><strong>Nome de Utilizador:</strong> <?php echo $nomeUtilizador; ?></p>
    <p><strong>Número:</strong> <?php echo $numero; ?></p>
  </div>
  
  <div class="content">
    <h2>Posts</h2>
    <?php
    if ($resultPosts->num_rows > 0) {
        while ($rowPosts = $resultPosts->fetch_assoc()) {
            $postID = $rowPosts['id']; // ID do post
            $titulo = $rowPosts['titulo'];
            $empresa = $rowPosts['empresa'];
            $tipotrabalho = $rowPosts['tipoTrabalho'];
            $ordenado = $rowPosts['ordenado'];
            $tempo = $rowPosts['tempo'];
            $descricao = $rowPosts['descricao'];
            echo "<h2>$titulo</h2>";
            echo "<p><strong>Empresa/Pessoal:</strong> $empresa</p>";
            echo "<p><strong>Tipo de trabalho:</strong> $tipotrabalho</p>";
            echo "<p><strong>Remuneração:</strong> $ordenado</p>";
            echo "<p><strong>Tempo:</strong>$tempo</p>";
            echo "<p><strong>Descrição:</strong>$descricao</p>";
            echo "<form action='eliminar_post.php' method='post'>";
            echo "<input type='hidden' name='postID' value='$postID'>";
            echo "<input type='submit' value='Eliminar Post'>";
            echo "</form>";
            echo "<hr>";
        }
    } else {
        echo "<p>Nenhum post encontrado.</p>";
    }
    ?>
  </div>
</body>
</html>
