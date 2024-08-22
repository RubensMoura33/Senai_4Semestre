import React from 'react';
import './Input.css'
import Search from '../../assets/icons/search.svg'
const Input = ({search}) => {
    return (

        <div className='input'>
            <img className='teste' src={Search} alt="" />
        <input  onChange={(e) => {
search(e.target.value)
        }} className='inp'   placeholder='Procurar tarefa'>
        </input>

           
        </div>
    );
};

export default Input;