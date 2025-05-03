import { createRoute } from '@tanstack/react-router';
import { rootRoute } from './__root';
import { IndexPage } from '@/pages/IndexPage';

export const indexRoute = createRoute({
  getParentRoute: () => rootRoute,
  path: '/',
  component: IndexPage,
});
