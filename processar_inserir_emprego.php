<?php
session_start();
if (!isset($_SESSION['utilizador'])) {
    header('Location: login.php');
    exit;
}


require_once 'db_conn.php';

$utilizador_id = $_SESSION['utilizador'];

$checkUser = "SELECT id FROM utilizador WHERE id = ?";
$stmt = $mysqli->prepare($checkUser);
$stmt->bind_param("i", $utilizador_id);
$stmt->execute();
$result = $stmt->get_result();

if ($result->num_rows > 0) {

    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        $titulo = $_POST['titulo'];
        $empresa = $_POST['empresa'];
        $tipoTrabalho = $_POST['tipoTrabalho'];
        $ordenado = $_POST['ordenado'];
        $tempo = $_POST['tempo'];
        $descricao = $_POST['descricao'];

        $sql = "INSERT INTO post (utilizador_id, titulo, empresa, tipoTrabalho, ordenado, tempo, descricao) VALUES (?, ?, ?, ?, ?, ?, ?)";
        $stmt = $mysqli->prepare($sql);
        $stmt->bind_param("issssss", $utilizador_id, $titulo, $empresa, $tipoTrabalho, $ordenado, $tempo, $descricao);

        if ($stmt->execute()) {
            header('Location: InserirEmprego.php');
    exit;
        } else {
            echo "Ocorreu um erro ao inserir o emprego: " . $stmt->error;
        }

        $stmt->close();
    } else {
        echo "Ocorreu um erro ao processar o formulário.";
    }
} else {
    echo "O usuário atual não existe.";
}
$mysqli->close();
?>
