import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Col, Row, theme } from 'antd';
import ArticleList from '../components/ArticleList';

const HomeContent: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
    
  const style: React.CSSProperties = { background: colorBgContainer, padding: '8px 0' };
  return (
    <div style={{background: "#f5f5f5"}}>
      <Row gutter={16}>
        <Col className="gutter-row" flex={5}>
          <Routes>
            <Route path='/' element={<ArticleList/>}></Route>
            <Route path='/Home' element={<ArticleList/>}></Route>
          </Routes>
        </Col>
        <Col className="gutter-row" flex={3}>
          <div style={style}>col-6</div>
        </Col>
      </Row>
    </div>
  );
};

export default HomeContent;