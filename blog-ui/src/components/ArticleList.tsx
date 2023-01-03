import React, { useEffect, useState } from 'react'
import ArticleCard from './ArticleCard'
import hotArticleList from '../api/article';

const ArticleList: React.FC = () => {
  const [hotArticles, setHotArticless] = useState([]);

  useEffect(() => {
    if(hotArticles.length != 0) return;

    hotArticleList()
    .then(response => {
      setHotArticless(response.data);
    })
    .catch(reason => {
      alert(reason)
    });
  })

  return (
    <div>
      {hotArticles.map(it => <ArticleCard tag={'Java'} {...it}></ArticleCard>)}
    </div>
  );
}

export default ArticleList;
