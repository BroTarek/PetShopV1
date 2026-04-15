import CommunitySection from "@/app/(MainPage)/CommunitySection";
import FeaturedPetsSection from "@/app/(MainPage)/FeaturedPetsSection";
import FeaturedProducts from "@/app/(MainPage)/FeaturedProducts";
import HeroSection from "@/app/(MainPage)/HeroSection";
import Newsletter from "@/app/(MainPage)/Newsletter";
export default function Home() {
  return (
    <>
      <HeroSection />
      <FeaturedPetsSection />
      <FeaturedProducts />
      <CommunitySection />
      <Newsletter />
    </>
  );
}
