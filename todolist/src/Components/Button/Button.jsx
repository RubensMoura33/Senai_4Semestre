import React from 'react';
import './Button.css';
const Button = ({name, largura, altura, onClick}) => {
    return (
      <>
      <button  onClick={onClick} style={{width: largura, height: altura }} className='btn'>{name}</button>
      </>
    );
};

export default Button;