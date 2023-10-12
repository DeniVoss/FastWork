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
    $nomeUti = $row['nome'];
} else {
    $nomeUti = "Nome do Utilizador";
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Empregos</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" type="text/css" href="empregos.css">
</head>
<body>
<div id="header">
  <a href="perfil.php" id="username"><?php echo $nomeUti; ?></a>
  <h3 id="header-title">FastWork</h3>
  <a href="homepage2.php?logout=true" id="logout-btn">Logout</a>
</div>
  
<div id="navbar">
    <a href="homepage2.php">Home</a>
    <a href="empregos.php">Oferta Empregos</a>
    <a href="InserirEmprego.php">Inserir Emprego</a>
    <a href="Suporte.php">Suporte</a>
  </div>

<div class="container">
  <form id="jobSearchForm">
    <input type="text" id="searchInput" placeholder="Procurar por título, tipo de trabalho ou empresa">
    <button type="submit" class="botaoS">Pesquisar</button>
  </form>
</div>
<div class="logo">
    <img src="imagens/logotipoO.png" alt="">
</div>
<div class="container">
  <h1>Lista de Empregos</h1>
  <?php
  require_once 'db_conn.php';

  // Lógica de pesquisa
  $searchQuery = "";
  
  if (isset($_GET['search'])) {
      $searchQuery = $_GET['search'];
  }
  
  $sql = "SELECT post.*, utilizador.nome, utilizador.apelido, utilizador.numero FROM post
          INNER JOIN utilizador ON post.utilizador_id = utilizador.id
          WHERE post.titulo LIKE '%$searchQuery%' OR post.tipoTrabalho LIKE '%$searchQuery%' OR post.empresa LIKE '%$searchQuery%' ORDER BY post.id DESC";
  $result = $mysqli->query($sql);

  if ($result && $result->num_rows > 0) {
      while ($row = $result->fetch_assoc()) {
          echo '<div class="post">';
          echo '<h2>' . $row['titulo'] . '</h2>';
          echo '<p><span>Empresa/Pessoal:</span> ' . $row['empresa'] . '</p>';
          echo '<p><span>Tipo de Trabalho:</span> ' . $row['tipoTrabalho'] . '</p>';
          echo '<p><span>Remuneração:</span> ' . $row['ordenado'] . '</p>';
          echo '<p><span>Tempo:</span> ' . $row['tempo'] . '</p>';
          echo '<p><span>Descrição:</span> ' . $row['descricao'] . '</p>';
          echo '<p><span>Data de Criação:</span> ' . $row['data_criacao'] . '</p>';
          echo '<p><span>Utilizador:</span> <a href="perfil_utilizador.php?id=' . $row['utilizador_id'] . '">' . $row['nome'] . ' ' . $row['apelido'] . '</a></p>';
          echo '<p><span>Numero de telefone:</span> ' . $row['numero'] . '</p>';

          $emailRemetente = is_array($_SESSION['utilizador']) ? $_SESSION['utilizador']['email'] : '';

          $idPost = $row['id'];

          $sqlEmail = "SELECT email FROM utilizador WHERE id = (SELECT utilizador_id FROM post WHERE id = '$idPost')";
          $resultadoEmail = $mysqli->query($sqlEmail);

          if ($resultadoEmail && $resultadoEmail->num_rows > 0) {
              $rowEmail = $resultadoEmail->fetch_assoc();
              $emailDestinatario = $rowEmail['email'];
          } else {
              $emailDestinatario = "";
          }

          if (!empty($emailDestinatario)) {
            echo '<form method="post" action="enviar_curriculo.php" enctype="multipart/form-data">';
            echo '<input type="hidden" name="idPost" value="' . $idPost . '">';
            echo '<input type="hidden" name="emailDestinatario" value="' . $emailDestinatario . '">';
            echo '<input type="hidden" name="emailRemetente" value="' . $emailRemetente . '">';
            echo '<input type="hidden" name="tituloEmprego" value="' . $row['titulo'] . '">';
            echo '<input id="selecionar-' . $idPost . '" type="file" name="curriculo" class="botaoE" onchange="showSelectedFileName(\'selecionar-' . $idPost . '\', \'label-' . $idPost . '\');">';
            echo '<label id="label-' . $idPost . '" for="selecionar-' . $idPost . '">Selecionar um arquivo</label>';
            echo '<input type="submit" value="Enviar Currículo" class="botaoS" onclick="showLoadingAnimation();">';
            echo '</form>';
        }
          echo '</div>';
      }
  } else {
      echo '<p class="no-posts">Nenhum emprego encontrado.</p>';
  }

  $mysqli->close();
  ?>
</div>
<div id="loading-overlay">
    <div id="loading-spinner"></div>
</div>

<script>
   function showSelectedFileName(inputId, labelId) {
        var inputFile = document.getElementById(inputId);
        var fileName = inputFile.files[0].name;
        var label = document.getElementById(labelId);
        label.textContent = 'Arquivo selecionado: ' + fileName;
    }

function showLoading() {
    var loadingOverlay = document.getElementById('loading-overlay');
    loadingOverlay.classList.add('visible');
  }

  function stopLoading() {
    var loadingOverlay = document.getElementById('loading-overlay');
    loadingOverlay.classList.remove('visible');
  }
function showLoadingAnimation() {
    $('#loading-overlay').addClass('visible');
}

    function hideLoadingAnimation() {
        $('#loading-overlay').fadeOut();
    }

    document.getElementById('jobSearchForm').addEventListener('submit', function(e) {
        e.preventDefault(); 
        var searchQuery = document.getElementById('searchInput').value;
        var url = window.location.href.split('?')[0]; 

        
        showLoadingAnimation();

        
        setTimeout(function() {
            window.location.href = url + '?search=' + encodeURIComponent(searchQuery);
        }, 500); 
    });
    $(window).on('load', function() {
        hideLoadingAnimation();
    });
</script>

</body>
</html>
