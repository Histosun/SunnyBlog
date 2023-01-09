import React, { useEffect, useState } from 'react'
import { Badge, message, Card } from 'antd';
import { hotArticleList } from '../../api/article';
import HotArticleItem, { HotArticle } from '../../components/article/HotArticleItem';

const HotArticles: React.FC = () => {
  const [hotArticles, setHotArticles] = useState([] as HotArticle[]);
  const [messageApi, contextHolder] = message.useMessage();

  useEffect(() => {
    if (hotArticles.length != 0) return;

    hotArticleList()
      .then(response => {
        console.log(response.data)
        setHotArticles(response.data);
      })
      .catch(reason => {
        messageApi.open({
          type: 'error',
          content: "Unable to load hot articles!",
        });
      });
  })
  return (
    <Badge.Ribbon text={"hot articles"} placement='start' color='red'>
      {contextHolder}
      <Card bordered={false}>
        {hotArticles.map(it => <HotArticleItem key={it.id} {...it}></HotArticleItem>)}
      </Card>
    </Badge.Ribbon>
  );
}

export default HotArticles;
