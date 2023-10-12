<?php
session_start();

if (!isset($_SESSION['utilizador'])) {
    header("Location: login.php");
    exit();
}

if (isset($_POST['postID'])) {

    $postID = $_POST['postID'];

    require_once 'db_conn.php';

    $utilizadorID = $_SESSION['utilizador'];
    $query = "SELECT id FROM post WHERE id = $postID AND utilizador_id = $utilizadorID";
    $result = $mysqli->query($query);

    if ($result->num_rows > 0) {

        $deleteQuery = "DELETE FROM post WHERE id = $postID";
        if ($mysqli->query($deleteQuery)) {
            header("Location: perfil.php");
            exit();
        } else {
            echo "Ocorreu um erro ao excluir o post. Por favor, tente novamente.";
        }
    } else {
        echo "Não tem permissão para excluir este post.";
    }

    $mysqli->close();
} else {
    header("Location: perfil.php");
    exit();
}
?>
