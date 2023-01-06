import React from 'react';
import { useRoutes } from 'react-router-dom';
import { Col, Row, theme } from 'antd';
import routes from '../routes/'

const HomeContent: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
    
  const style: React.CSSProperties = { background: colorBgContainer, padding: '8px 0' };
  const elements = useRoutes(routes)

  return (
    <div style={{background: "#f5f5f5"}}>
      <Row gutter={16}>
        <Col className="gutter-row" flex={5}>
          {elements}
        </Col>
        <Col className="gutter-row" flex={3}>
          <div style={style}>col-6</div>
        </Col>
      </Row>
    </div>
  );
};

export default HomeContent;