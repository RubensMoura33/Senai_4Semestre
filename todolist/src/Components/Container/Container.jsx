import React from 'react';
import './Container.css'
const Container = ({altura, largura, children}) => {
    return (
        <div className='container2' style={{height: altura, width: largura}}>
          {children}
        </div>
    );
};

export default Container;