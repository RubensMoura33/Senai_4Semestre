import React from 'react';
import './Container2.css'
const Container2 = ({altura, largura, children}) => {
    return (
        <div className='container3' style={{height: altura, width: largura}}>
          {children}
        </div>
    );
};

export default Container2;