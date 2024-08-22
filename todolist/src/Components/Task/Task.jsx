import React, { useState } from "react";
import "./Task.css";
import Edit from "../../assets/icons/edit.svg";
import Cancel from "../../assets/icons/cancel.svg";
import EditWhite from "../../assets/icons/pencilWhite.svg";
import CancelWhite from "../../assets/icons/cancelWhite.svg";

const Task = ({ tarefaName, onClick , id, editClick}) => {
  const [isChecked, setIsChecked] = useState(false);

  const setHandleCheckbox  = () => {
    setIsChecked(!isChecked)
  }
  return (
    <>

        <div className={`taskHeight ${isChecked ? 'checked' : ''}`}>
        <div className="d-flex">
          <input type="checkbox"  onChange={setHandleCheckbox}/>
          <p className={`colorP ${isChecked ? 'checked' : ''}`}>{tarefaName}</p>
        </div>

        <div className="d-flex">
          <button onClick={(e) => {
              onClick(id);
          }} className={`btnTask ${isChecked ? 'btnTask2' : ''}`}>
            <img   src={isChecked ? CancelWhite : Cancel } alt="" />
          </button>
          <button className={`btnTask ${isChecked ? 'btnTask2' : ''}`} onClick={(e) => {
            editClick(tarefaName, id)
          }}>
            <img  src={isChecked ? EditWhite : Edit} alt="" />
          </button>
        </div>
      </div>
    </>
  );
};

export default Task;

