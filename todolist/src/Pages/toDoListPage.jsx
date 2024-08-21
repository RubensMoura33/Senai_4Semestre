import "./toDoListPage.css";
import Vector from "../assets/Vector.png"

const Form = () => {
    const today = new Date();
    const day = today.getDate();
    const dayOfWeek = today.toLocaleDateString('pt-BR', { weekday: 'long' });
    const month = today.toLocaleDateString('pt-BR', { month: 'long' });

    const tasks = [
        { id: 1, name: "Começar a execução do projeto", status: false },
        { id: 2, name: "Revisar documentação", status: true },
        { id: 3, name: "Enviar relatório semanal", status: false },
    ]


    return (
        <main className="main-content">
            <div className="body">
                <div className="box">
                    <p className="date">{dayOfWeek}, {day} de {month}</p>

                    <div className="search-task">
                        <img src={Vector} alt="" />
                        <input type="text" placeholder="Procurar tarefa" />
                    </div>
                    <div className="task-list">
                        {tasks.map((task) =>
                            <div className="task-item">
                                <input type="checkbox" id={`task-${task.id}`} defaultChecked={task.status} />
                                <label>{task.name}</label>
                                <button className="delete-btn">&#10006;</button>
                                <button className="edit-btn">&#9998;</button>
                            </div>
                        )}
                    </div>
                </div>


                <button className="btn-new-task">Nova tarefa</button>
            </div>
        </main>
    );
};

export default Form;
