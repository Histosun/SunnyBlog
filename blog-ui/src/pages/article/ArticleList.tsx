import React, { useEffect, useState } from 'react'
import { message } from 'antd';
import ArticleCard, { ArticleCardProps } from '../../components/article/ArticleCard'
import { getArticleList } from '../../api/article';

const ArticleList: React.FC = () => {
  const [articleList, setArticleList] = useState([] as ArticleCardProps[]);
  const [messageApi, contextHolder] = message.useMessage();

  useEffect(() => {
    if (articleList.length != 0) return;

    getArticleList(0)
      .then(response => {
        setArticleList(response.data);
      })
      .catch(reason => {
        messageApi.open({
          type: 'error',
          content: "reason",
        });
      });
  })

  return (
    <div>
      {contextHolder}
      {articleList.map(it => <ArticleCard key={it.id} {...it}></ArticleCard>)}
    </div>
  );
}

export default ArticleList;
