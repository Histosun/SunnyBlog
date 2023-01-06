import React, {useState, useEffect} from 'react'
import { Typography } from 'antd';
import { useParams } from 'react-router-dom';
import { getArticleDetail } from '../../api/article';
import ReactMarkdown from 'react-markdown';

const { Title, Paragraph, Text, Link } = Typography;

interface ArticleDetailProp {
  title: string,
  content: string,
  viewCount: number,
  created: Date
}

const ArticleDetail: React.FC = () => {
  const params = useParams();
  const [articleDetail, setArticleDetail] = useState({} as ArticleDetailProp);

  useEffect(() => {
    if(!params.id) return;
    const id = params.id || '1'
    getArticleDetail(id)
    .then(response => {
      setArticleDetail(response.data);
    })
    .catch(reason => {
      alert(reason)
    });
  }, [params.id])

  return (
    <Typography>
      <Title>{articleDetail.title}</Title>
      <ReactMarkdown>{articleDetail.content}</ReactMarkdown>
    </Typography>
  );
}

export default ArticleDetail;
