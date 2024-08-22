import logo from "./logo.svg";
import "./App.css";
import Button from "./Components/Button/Button";
import Container from "./Components/Container/Container";
import { useEffect, useState } from "react";
import Input from "./Components/Input/Input";
import Modal from "./Components/Modal/Modal";
import Task from "./Components/Task/Task";

function App() {
  const [Array, setArray] = useState([]);
  const [filtrarArray, setFiltrarArray] = useState(Array);

  const removeTask = (id) => {
    setArray((e) => {
      return e.filter((x) => x.id != id);
    });
  };

  const editTask = (description, id) => {
    setDescription(description);
    setIdTarefa(id);
    setExibir(true);
  };
  const editarTarefa = (id, description) => {
    setArray((e) => {
      return e.map((x) => 
        x.id == id ? { ...x, description } : x
      );
    });

    setExibir(false);
  };


const BuscarTarfefa = (valor) => {
  setFiltrarArray(valor)
}
  const addTask = (description) => {
    const newTask = { id: Array.length + 1, description };
    setArray([...Array, newTask]);

    setExibir(false);
  };

  const [mes, setMes] = useState();
  const [dia, setDia] = useState();
  const [exibir, setExibir] = useState(false);
  const [description, setDescription] = useState(null);
  const [idTarefa, setIdTarefa] = useState(null);
  useEffect(() => {
    buscarMes();
    buscarDia();
  }, []);

  function buscarDia() {
    var diaSemana = [
      "domingo",
      "segunda-feira",
      "terça-feira",
      "quarta-feira",
      "quinta-feira",
      "sexta-feira",
      "sábado",
    ];

    var diaAtual = new Date().getDay();

    setDia(diaSemana[diaAtual]);
  }

  function buscarMes() {
    var meses = [
      "janeiro",
      "fevereiro",
      "março",
      "abril",
      "maio",
      "junho",
      "julho",
      "agosto",
      "setembro",
      "outubro",
      "novembro",
      "dezembro",
    ];

    var mesAtual = new Date().getMonth();

    setMes(meses[mesAtual]);
  }


  return (
    <>
      <div className="container">
      <div className="organizar">
        <Container altura={495} largura={743}>
          <p>
            {dia},{" "}
            <span style={{ color: "#8758FF" }}>{new Date().getDate()}</span> de{" "}
            {mes}{" "}
          </p>
          <Input search={BuscarTarfefa}/>

          <div className="containerCards">
            {Array.filter(x => x.description.includes(filtrarArray)).map((e) => {
              return (
                <Task
                  editClick={editTask}
                  onClick={removeTask}
                  tarefaName={e.description}
                  id={e.id}
                />
              );
            })}

          </div>
        </Container>
        <Button
          onClick={() => setExibir(true)}
          largura={200}
          altura={49}
          name={"Nova Tarefa"}
        />

        {exibir ? (
          <Modal
            editTask={editarTarefa}
            idTask={idTarefa}
            description={description}
            onAddTask={addTask}
          />
        ) : null}

      </div>
      </div>
    </>
  );
}

export default App;
