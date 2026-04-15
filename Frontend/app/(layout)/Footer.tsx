import Link from 'next/link'
import React from 'react'

const Footer = () => {
  return (
    <footer className="bg-surface-container-low dark:bg-primary-container w-full rounded-t-lg mt-20">
        <div className="grid grid-cols-1 md:grid-cols-4 gap-12 px-12 py-20 max-w-screen-2xl mx-auto">
            <div className="col-span-1 md:col-span-1">
                <div className="text-xl font-black text-on-surface dark:text-surface mb-4 font-headline">The Curated Companion</div>
                <p className="text-on-surface-variant dark:text-outline-variant font-headline text-sm leading-relaxed mb-6">
                    Redefining the relationship between pets and their humans through curated selection and thoughtful
                    care.
                </p>
                <div className="flex gap-4">
                    <span className="material-symbols-outlined text-on-surface-variant"
                        data-icon="facebook">social_leaderboard</span>
                    <span className="material-symbols-outlined text-on-surface-variant" data-icon="instagram">retweet</span>
                    <span className="material-symbols-outlined text-on-surface-variant" data-icon="youtube">video_youtube</span>
                </div>
            </div>
            <div>
                <h4 className="font-bold text-on-surface dark:text-surface mb-6 font-headline">Shop</h4>
                <ul className="space-y-4">
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">New Arrivals</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Best Sellers</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Accessories</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Nutrition</Link></li>
                </ul>
            </div>
            <div>
                <h4 className="font-bold text-on-surface dark:text-surface mb-6 font-headline">Support</h4>
                <ul className="space-y-4">
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Return Policy</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Shipping Info</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Contact Us</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">FAQ</Link></li>
                </ul>
            </div>
            <div>
                <h4 className="font-bold text-on-surface dark:text-surface mb-6 font-headline">Connect</h4>
                <ul className="space-y-4">
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Newsletter</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Store Locator</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Pet Care Blog</Link></li>
                    <li><Link className="text-on-surface-variant font-headline text-sm hover:text-on-surface underline-offset-4 decoration-secondary-fixed hover:underline"
                            href="#">Our Story</Link></li>
                </ul>
            </div>
        </div>
        <div
            className="px-12 py-8 border-t border-outline-variant/10 max-w-screen-2xl mx-auto flex flex-col md:flex-row justify-between items-center gap-4">
            <p className="text-on-surface-variant font-headline text-sm">© 2024 The Curated Companion. All rights reserved.</p>
            <div className="flex gap-8">
                <Link className="text-on-surface-variant font-headline text-xs" href="#">Privacy Policy</Link>
                <Link className="text-on-surface-variant font-headline text-xs" href="#">Terms of Service</Link>
            </div>
        </div>
    </footer>
  )
}

export default Footer