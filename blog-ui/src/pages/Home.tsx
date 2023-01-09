import React, { useState } from 'react';
import { useRoutes } from 'react-router-dom';
import type { MenuProps } from 'antd';
import { Layout, theme } from 'antd';
import routes from '../routes/'
import HomeMenu from '../components/HomeMenu';

type MenuItem = Required<MenuProps>['items'][number];
const { Header, Content, Footer } = Layout;

const Home: React.FC = () => {
  const {
    token: { colorBgContainer },
  } = theme.useToken();
  const elements = useRoutes(routes)

  // const {user}=useUser();
  // console.log(user)

  return (
    <Layout className="layout">
      <Header>
        <HomeMenu />
      </Header>
      <Content style={{ padding: '0 50px' }}>
        {/* <Breadcrumb style={{ margin: '16px 0' }}>
          <Breadcrumb.Item>
            <NavLink to = "/Home">Home</NavLink>
          </Breadcrumb.Item>
          <Breadcrumb.Item>
            <NavLink to = "/Home/List">List</NavLink>
          </Breadcrumb.Item>
        </Breadcrumb> */}
        <div className="site-layout-content" style={{ background: colorBgContainer, marginTop: 20 }}>
          {elements}
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>Ant Design ©2018 Created by Ant UED</Footer>
    </Layout>
  );
};

export default Home;