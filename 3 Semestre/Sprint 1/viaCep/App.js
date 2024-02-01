import { StatusBar } from 'react-native';
import { ContainerApp } from './style';
import { useFonts, Roboto_500Medium, Roboto_700Bold } from '@expo-google-fonts/roboto';
import { Header } from './src/components/Header';
import { Home } from './src/screens/Home/Index';

export default function App() {
  let [fonts] = useFonts({
    Roboto_500Medium, Roboto_700Bold
  });

  if (!fonts) {
    return null;
  }
  return (
    <ContainerApp>
      <StatusBar backgroundColor='transparent' translucent />
      <Header />
      <Home />
    </ContainerApp>
  );
}
