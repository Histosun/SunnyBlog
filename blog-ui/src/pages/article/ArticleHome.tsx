import React from 'react';
import { Col, Row, theme } from 'antd';
import ArticleList from './ArticleList';
import HotArticles from './HotArticles';

const ArticleHome: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
    
  const style: React.CSSProperties = { background: colorBgContainer, padding: '8px 0' };

  return (
    <div style={{background: "#f5f5f5"}}>
      <Row gutter={16}>
        <Col className="gutter-row" flex={5}>
          <ArticleList/>
        </Col>
        <Col className="gutter-row" flex={3}>
          <HotArticles></HotArticles>
        </Col>
      </Row>
    </div>
  );
};

export default ArticleHome;