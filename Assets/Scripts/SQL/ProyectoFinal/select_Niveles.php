<?php
header("Content-Type: application/json");

$mysqli = new mysqli("localhost", "root", "", "juegoPuntaje");

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $sql = "SELECT * FROM Niveles";
    $result = $mysqli->query($sql);

    $niveles = [];
    while ($row = $result->fetch_assoc()) {
        $nivel = [
            "Niveles_id" => $row["Niveles_id"],
            "nombre" => $row["nombre"],
            "tiempo" => $row["tiempo"]
        ];
        $niveles[] = $nivel;
    }

    if (!empty($niveles)) {
        echo json_encode(["message" => "Niveles disponibles encontrados con éxito", "data" => ["niveles" => $niveles]]);
    } else {
        echo json_encode(["message" => "No se encontraron niveles disponibles", "data" => null]);
    }
}

$mysqli->close();
?>