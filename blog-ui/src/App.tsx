import React, { useContext, useState } from 'react';
import { ConfigProvider } from 'antd';

import Home from "./pages/Home";
import { AuthProvider } from './context/AuthProvider';

const App: React.FC = () => {
  return (
    <AuthProvider>
      <Home/>
    </AuthProvider>
  );
};

export default App;