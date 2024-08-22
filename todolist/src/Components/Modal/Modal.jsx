import React, { useState } from 'react';
import Button from '../Button/Button';
import './Modal.css'
const Modal = ({  onAddTask, description, idTask, editTask }) => {

    const [taskDescription, setTaskDescription] = useState(description);
    function adicionarTask() {
    
        onAddTask(taskDescription); 
    }

    function editarTask(){
     editTask(idTask, taskDescription)
    }
    return (
       <>
       <div className='modal'>
       
              <p>Descreva sua tarefa</p>
              <input value={taskDescription} onChange={(e) => setTaskDescription(e.target.value)} placeholder='Exemplo de descrição' className='intModal'></input>
         

         <Button onClick={() => {
            description == null ?   adicionarTask() : editarTask();
          
            
         
         }} altura={64} largura={322} name={description == null ? "Cadastrar Tarefa" : "Editar Tarefa"}/>
       </div>
       </>
    );
};

export default Modal;



// Outras importações permanecem iguais

// const Modal = ({ onClick, arrayy, onAddTask }) => {
//    

//     function adicionarTask() {
    
//         onAddTask(taskDescription); 
//     }

//     return (
//         <>
//             <div className='modal'>
//                 <p>Descreva sua tarefa</p>
//                 <input placeholder='Exemplo de descrição' className='intModal'
//                        onChange={(e) => setTaskDescription(e.target.value)}></input>

//                 <Button onClick={adicionarTask} altura={64} largura={322} name={"Confirmar Tarefa"}/>
//             </div>
//         </>
//     );
// };

// export default Modal;
