import React from 'react';
import { Row, Col } from 'antd';
import { HomeOutlined, UnorderedListOutlined, UserOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Layout, Menu } from 'antd';

type MenuItem = Required<MenuProps>['items'][number];
const { Header, Content, Footer } = Layout;

const HomeMenu: React.FC = () => {

  return (
    <Row gutter={16}>
        <Col className="gutter-row" flex={5}>
            <Menu theme="dark" mode="horizontal" items={leftItems}/>
        </Col>
        <Col className="gutter-row" flex={5}>
            <Menu selectable={false} theme="dark" mode="horizontal" items={rightItems} style={{justifyContent: 'flex-end'}}/>
        </Col>
    </Row>
  );
};

const leftItems: MenuItem[] = [
    {key: "home", icon: <HomeOutlined/>, label: "Home"},
    {key: "category", icon: <UnorderedListOutlined/>, label: "Category"},
];

const rightItems: MenuItem[] = [
    {key: "home", icon: <UserOutlined/>, label: "Login"}
];

export default HomeMenu;