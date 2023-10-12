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
    $nomeUtilizador  = "Nome do Usuário";
}

if (isset($_GET['id'])) {
    $perfilID = $_GET['id'];

    $perfilQuery = "SELECT * FROM utilizador WHERE id = $perfilID";
    $perfilResult = $mysqli->query($perfilQuery);

    if ($perfilResult->num_rows > 0) {
        $perfilRow = $perfilResult->fetch_assoc();
        $perfilNome = $perfilRow['nome'];
        $perfilApelido = $perfilRow['apelido'];
        $perfilEmail = $perfilRow['email'];
        $perfilNumero = $perfilRow['numero'];
    } else {

        $perfilNome = "Nome do Utilizador";
        $perfilApelido = "Apelido do Utilizador";
        $perfilEmail = "Email do Utilizador";
        $perfilNumero = "Número do Utilizador";
    }

    $postsQuery = "SELECT * FROM post WHERE utilizador_id = $perfilID";
    $postsResult = $mysqli->query($postsQuery);
} else {
    $perfilNome = "Nome do Usuário";
    $perfilApelido = "Apelido do Usuário";
    $perfilEmail = "Email do Usuário";
    $perfilNumero = "Número do Usuário";
    $postsResult = false;
}

?>
<!DOCTYPE html>
<html>
<head>
    <title>Perfil do Utilizador</title>
    <link rel="stylesheet" type="text/css" href="perfil.css">
    
</head>
<body>
    <div id="header">
        <a href="perfil.php" id="username"><?php echo $nomeUtilizador; ?></a>
        <a href="homepage2.php?logout=true" id="logout-btn">Logout</a>
    </div>

    <div id="navbar">
        <a href="homepage2.php">Home</a>
        <a href="empregos.php">Empregos</a>
        <a href="InserirEmprego.php">Inserir Emprego</a>
        <a href="Suporte.php">Suporte</a>
    </div>

    <div class="container">
        <h1>Perfil do Utilizador</h1>
        <h2><?php echo $perfilNome; ?> <?php echo $perfilApelido; ?></h2>
        <p><span>Email:</span> <?php echo $perfilEmail; ?></p>
        <p><span>Número de telefone:</span> <?php echo $perfilNumero; ?></p>
    </div>

    <div class="container">
        <h1>Posts</h1>
        <?php
        if ($postsResult && $postsResult->num_rows > 0) {
            while ($postRow = $postsResult->fetch_assoc()) {
                echo '<div class="post">';
                echo '<h2>' . $postRow['titulo'] . '</h2>';
                echo '<p><span>Empresa:</span> ' . $postRow['empresa'] . '</p>';
                echo '<p><span>Tipo de Trabalho:</span> ' . $postRow['tipoTrabalho'] . '</p>';
                echo '<p><span>Ordenado:</span> ' . $postRow['ordenado'] . '</p>';
                echo '<p><span>Tempo:</span> ' . $postRow['tempo'] . '</p>';
                echo '<p><span>Descrição:</span> ' . $postRow['descricao'] . '</p>';
                echo '<p><span>Data de Criação:</span> ' . $postRow['data_criacao'] . '</p>';
                echo '</div>';
            }
        } else {
            echo '<p class="no-posts">Nenhum post encontrado.</p>';
        }
        $mysqli->close();
        ?>
    </div>
</body>
</html>
