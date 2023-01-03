import React, {useState} from 'react';
import { HomeOutlined, UnorderedListOutlined } from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import { NavLink } from 'react-router-dom';
import Home1 from './Home1';

type MenuItem = Required<MenuProps>['items'][number];
const { Header, Content, Footer } = Layout;

const Home: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();

  const items: MenuItem[] = [
    {key: "home", icon: <HomeOutlined/>, label: "Home"},
    {key: "category", icon: <UnorderedListOutlined/>, label: "Category"},
  ];

  return (
    <Layout className="layout">
      <Header>
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          items={items}
        />
      </Header>
      <Content style={{ padding: '0 50px' }}>
        <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item>
            <NavLink to = "/Home">Home</NavLink>
          </Breadcrumb.Item>
          <Breadcrumb.Item>
            <NavLink to = "/Home/List">List</NavLink>
          </Breadcrumb.Item>
        </Breadcrumb>
        <div className="site-layout-content" style={{ background: colorBgContainer }}>
          <Home1></Home1>
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
    </Layout>
  );
};

export default Home;